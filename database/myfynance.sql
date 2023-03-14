CREATE DATABASE myfinance

USE myfinance

CREATE TABLE planoconta(
	id IDENTITY NOT NULL,
	descricao VARCHAR(50) NOT NULL,
	tipo CHAR(1),
	PRIMARY KEY (id)
);

CREATE TABLE transacao(
	id PRIMARY KEY IDENTITY NOT NULL,
	data VARCHAR(14) NOT NULL,
	valor DECIMAL(10,2) NOT NULL,
	historico TEXT,
	planocontaid INT NOT NULL
	PRIMARY KEY (ID),
	FOREIGN KEY(planocontaid) REFERENCES planoconta(id)	
);

/* MASSA DE DADOS */
INSERT INTO planoconta(descricao, tipo) VALUES('Combustível', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Alimentação', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Plano de Saúde', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('IPTU', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Salário', 'R')
INSERT INTO planoconta(descricao, tipo) VALUES('Dividendos de ações', 'R')

INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230214 21:00', 800, 'Gasolina Ferrari', 1)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230214 21:20', 100, 'Jantar MC Donalds', 2)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230213 10:47', 1000, 'Plano de saúde Bradesco', 3)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230212 11:00', 2000, 'IPTU Mansão Guarujá', 4)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230205 08:00', 100000, 'Salario Executivo', 5)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230205 09:00', 500000, 'Dividendos', 6)


