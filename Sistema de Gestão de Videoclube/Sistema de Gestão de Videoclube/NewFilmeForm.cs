using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using Sistema_de_Gestão_de_Videoclube.Classes;

namespace Sistema_de_Gestão_de_Videoclube
{
    public partial class NewFilmeForm : Form
    {
        private const string TMDB_API_KEY = "b74ed907fd01a8d31740e4676e5d67b4";
        private static readonly HttpClient _httpClient = new HttpClient();
        private bool _isUpdatingTextBoxProgrammatically = false;


        public NewFilmeForm()
        {
            InitializeComponent();
            
            timerSugestao.Tick += timerSugestao_Tick;
            timerSugestao.Interval = 500;

            lstSugestoesFilme.Visible = false;
            lstSugestoesFilme.DoubleClick += lstSugestoesFilme_DoubleClick;
            lstSugestoesFilme.KeyDown += lstSugestoesFilme_KeyDown;
        }

        private void NewFilmeForm_Load(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void novoFilmeOK_Click(object sender, EventArgs e)
        {
            SaveFilmeData();
        }

        private void txtFilme_TextChanged(object sender, EventArgs e)
        {
            if (_isUpdatingTextBoxProgrammatically)
            {
                return;
            }
            timerSugestao.Stop();
            if (txtFilme.Text.Length >= 3)
            {
                timerSugestao.Start();
            }
            else
            {
                lstSugestoesFilme.Visible = false;
            }
        }

        private async void timerSugestao_Tick(object sender, EventArgs e)
        {
            timerSugestao.Stop();
            await SearchMoviesAsync(txtFilme.Text);
        }

        private async Task SearchMoviesAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                lstSugestoesFilme.Visible = false;
                return;
            }

            try
            {
                string url = $"https://api.themoviedb.org/3/search/movie?api_key={TMDB_API_KEY}&query={Uri.EscapeDataString(query)}&language=pt-BR";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var searchResponse = JsonSerializer.Deserialize<TmdbSearchResponse>(jsonResponse);

                lstSugestoesFilme.Items.Clear();
                if (searchResponse?.Results != null && searchResponse.Results.Any())
                {
                    foreach (var movie in searchResponse.Results.OrderByDescending(m => m.ReleaseDate))
                    {
                        string displayTitle = movie.Title;
                        if (!string.IsNullOrEmpty(movie.ReleaseDate) && movie.ReleaseDate.Length >= 4)
                        {
                            displayTitle += $" ({movie.ReleaseDate.Substring(0, 4)})";
                        }
                        lstSugestoesFilme.Items.Add(new MovieSuggestion { DisplayText = displayTitle, TmdbId = movie.Id });
                    }
                    lstSugestoesFilme.Visible = true;
                    lstSugestoesFilme.Height = Math.Min(lstSugestoesFilme.PreferredHeight, 200);
                    lstSugestoesFilme.BringToFront();
                }
                else
                {
                    lstSugestoesFilme.Visible = false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Erro de conexão com a API: {ex.Message}", "Erro de API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lstSugestoesFilme.Visible = false;
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Erro ao processar dados da API: {ex.Message}", "Erro de API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lstSugestoesFilme.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lstSugestoesFilme.Visible = false;
            }
        }

        private class MovieSuggestion
        {
            public string DisplayText { get; set; }
            public int TmdbId { get; set; }
            public override string ToString() => DisplayText;
        }

        private async void lstSugestoesFilme_DoubleClick(object sender, EventArgs e)
        {
            if (lstSugestoesFilme.SelectedItem is MovieSuggestion selectedMovie)
            {
                await FillMovieDataAsync(selectedMovie.TmdbId);
                lstSugestoesFilme.Visible = false;
            }
        }

        private async void lstSugestoesFilme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lstSugestoesFilme.SelectedItem is MovieSuggestion selectedMovie)
                {
                    await FillMovieDataAsync(selectedMovie.TmdbId);
                    lstSugestoesFilme.Visible = false;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lstSugestoesFilme.Visible = false;
                txtFilme.Focus();
                e.Handled = true;
            }
        }

        private async Task FillMovieDataAsync(int tmdbId)
        {
            try
            {
                _isUpdatingTextBoxProgrammatically = true;
                string detailsUrl = $"https://api.themoviedb.org/3/movie/{tmdbId}?api_key={TMDB_API_KEY}&language=pt-BR";
                HttpResponseMessage detailsResponse = await _httpClient.GetAsync(detailsUrl);
                detailsResponse.EnsureSuccessStatusCode();
                string detailsJson = await detailsResponse.Content.ReadAsStringAsync();
                var movieDetails = JsonSerializer.Deserialize<TmdbMovieDetails>(detailsJson);

                string creditsUrl = $"https://api.themoviedb.org/3/movie/{tmdbId}/credits?api_key={TMDB_API_KEY}&language=pt-BR";
                HttpResponseMessage creditsResponse = await _httpClient.GetAsync(creditsUrl);
                creditsResponse.EnsureSuccessStatusCode();
                string creditsJson = await creditsResponse.Content.ReadAsStringAsync();
                var credits = JsonSerializer.Deserialize<TmdbCredits>(creditsJson);

                txtFilme.Text = movieDetails.Title;

                if (movieDetails.Genres != null && movieDetails.Genres.Any())
                {
                    txtGenero.Text = string.Join(", ", movieDetails.Genres.Select(g => g.Name));
                }
                else
                {
                    txtGenero.Text = string.Empty;
                }

                var director = credits?.Crew?.FirstOrDefault(c => c.Job == "Director");
                if (director != null)
                {
                    txtRealizador.Text = director.Name;
                }
                else
                {
                    txtRealizador.Text = string.Empty;
                }

                txtDuracao.Text = movieDetails.Runtime?.ToString() ?? string.Empty;

                if (!string.IsNullOrEmpty(movieDetails.ReleaseDate) && movieDetails.ReleaseDate.Length >= 4)
                {
                    txtAno.Text = movieDetails.ReleaseDate.Substring(0, 4);
                }
                else
                {
                    txtAno.Text = string.Empty;
                }

                txtFilme.SelectionStart = txtFilme.Text.Length;
                txtFilme.SelectionLength = 0;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Erro ao obter detalhes do filme: {ex.Message}", "Erro de API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Erro ao processar detalhes da API: {ex.Message}", "Erro de API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao preencher os dados do filme: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SaveFilmeData()
        {
            errorProvider1.Clear();
            FilmeClass filme = new FilmeClass();
            bool isValid = true;

            string titulo = txtFilme.Text.Trim();
            if (string.IsNullOrEmpty(titulo))
            {
                errorProvider1.SetError(txtFilme, "O campo Título é obrigatório.");
                isValid = false;
            }
            else
            {
                filme.Titulo = titulo;
            }

            string genero = txtGenero.Text.Trim();
            if (string.IsNullOrEmpty(genero))
            {
                errorProvider1.SetError(txtGenero, "O campo Género é obrigatório.");
                isValid = false;
            }
            else
            {
                filme.Genero = genero;
            }

            string realizador = txtRealizador.Text.Trim();
            if (string.IsNullOrEmpty(realizador))
            {
                errorProvider1.SetError(txtRealizador, "O campo Realizador é obrigatório.");
                isValid = false;
            }
            else
            {
                filme.Realizador = realizador;
            }

            int duracao;
            if (!int.TryParse(txtDuracao.Text.Trim(), out duracao))
            {
                errorProvider1.SetError(txtDuracao, "Por favor, insira um valor numérico válido para a Duração.");
                isValid = false;
            }
            else
            {
                filme.Duracao = duracao;
            }

            int anoLancamento;
            if (!int.TryParse(txtAno.Text.Trim(), out anoLancamento))
            {
                errorProvider1.SetError(txtAno, "Por favor, insira um valor numérico válido para o Ano de Lançamento.");
                isValid = false;
            }
            else
            {
                filme.AnoLancamento = anoLancamento;
            }

            if (!isValid)
            {
                MessageBox.Show("Por favor, corrija os erros assinalados no formulário.", "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string validationError;
            if (!filme.IsValid(out validationError))
            {
                MessageBox.Show(validationError, "Erro de Validação de Negócio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool tituloExiste = FilmeClass.ExisteTitulo(filme.Titulo);
                if (tituloExiste)
                {
                    errorProvider1.SetError(txtFilme, "O título já existe na base de dados.");
                    MessageBox.Show("O título já existe na base de dados. Por favor, escolha outro.", "Título Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFilme.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao verificar o título: {ex.Message}", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                filme.CreateFilme(filme);
                MessageBox.Show("Filme adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao guardar o filme: {ex.Message}", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void novofilmeCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}