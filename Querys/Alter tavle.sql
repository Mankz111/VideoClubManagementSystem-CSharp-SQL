ALTER TABLE Filme
ADD CONSTRAINT CK_Filme_Duracao CHECK (Duracao > 0 AND Duracao < 500);