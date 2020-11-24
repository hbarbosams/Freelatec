create DATABASE FreelaTec_bd;

go

use FreelaTec_bd

go

create table pessoa
(
	id			int				not null primary key identity,
	nome		varchar(200)	not null,
	login		varchar(30)		not null unique,
	senha		varchar(20)		not null,
	email		varchar(100)	not null unique,
	telefone	varchar(14)		not null,
	qtdProjetos	int,
	mediaNota	decimal(2,1),
	status		int,
	)
go 

create table contratante
(
	contratante_id		int		not null primary key references pessoa,
	descrContratante	Text	not null,
	areaAtuacao			Text	not null,
	cnpj				varchar(20)		not null unique
    

)
go 

create table freelancer
(
	freelancer_id		int			not null primary key references pessoa,
	ra					varchar(30)	not null,
	experiencia			Text,
	cpf					varchar(20)		not null unique
)
go 

create table contrato 
(
	nrContrato		int				not null primary key identity,
	dataContrato	datetime		not null,
	dataInicial		datetime			null,
	prazo			datetime			null,
	descricao		text			not null,
	total			money				null,
	status			int				not null,
	check	(status in (1,2,3,4)),
	notaContratante			int,
	check	(notaContratante between 0 and 5 ),
	notaFreelancer			int,
	check	(notaFreelancer between 0 and 5),
	contratante_id	int				not null foreign key references contratante(contratante_id),
	freelancer_id	int					null foreign key references freelancer(freelancer_id),
	taxa			money				null
)
go

create table proposta
(
	contrato_nr				int			not null references contrato,
	freelacer_id			int			not null references freelancer,
	totalProposto			money		not null,
	descricao				text,
	prazo					date		not null,
	primary key(contrato_nr, freelacer_id) -- chave primaria composta
)


go
create table projeto
(
	idProjeto				int				not null primary key identity,
	descricao		varchar(300)	not null
)
go

create table servico
(
	contrato_nr				int			not null references contrato,
	projeto_id				int			not null references freelancer,
	valor					money		not null,
	descricao				text		not null,
	primary key(contrato_nr, projeto_id) -- chave primaria composta
)
go

create procedure AddFreela
(
	@nome varchar(200), @login varchar(30), @senha varchar(20), @email varchar(100), @telefone varchar(14), @qtdProjetos int, @mediaNota decimal(2,1),
	@status int, 
	@cpf varchar(20), @ra varchar(30), @experiencia text
)

as
begin
    begin try
    begin tran
        insert into pessoa(nome,login,senha,email,telefone,qtdProjetos,mediaNota,status) 
		values(@nome, @login, @senha, @email, @telefone, @qtdProjetos, @mediaNota, @status) 
        insert into freelancer(freelancer_id, ra, experiencia, cpf) values (@@IDENTITY, @ra, @experiencia, @cpf)
        commit
    end try
    begin catch
        rollback
    end catch
end
go

Create procedure UpdateFreela
(
	@id int, @nome varchar(200), @login varchar(30), @senha varchar(20), @email varchar(100), @telefone varchar(14), @qtdProjetos int, @mediaNota decimal(2,1),
	@status int, 
    @ra varchar(30), @experiencia text
)

as
begin
    begin try
    begin tran
        update pessoa set nome = @nome, login = @login, senha = @senha, status = @status, telefone = @telefone, qtdProjetos = @qtdProjetos, mediaNota = @mediaNota,
		email = @email where id = @id 
        update freelancer set ra = @ra, experiencia = @experiencia where freelancer_id = @id
        commit
    end try
    begin catch
        rollback
    end catch
end
go

Create procedure AddContratante
(
	@nome varchar(200), @login varchar(30), @senha varchar(20), @email varchar(100), @telefone varchar(14), @qtdProjetos int, @mediaNota decimal(2,1),
	@status int, 
	@cnpj varchar(20), @areaAtuacao text, @descrContratante text
)

as
begin
    begin try
    begin tran
        insert into pessoa(nome,login,senha,email,telefone,qtdProjetos,mediaNota,status) 
		values(@nome, @login, @senha, @email, @telefone, @qtdProjetos, @mediaNota, @status) 
        insert into contratante(contratante_id, cnpj, areaAtuacao, descrContratante) values (@@IDENTITY, @cnpj, @areaAtuacao, @descrContratante)
        commit
    end try
    begin catch
        rollback
    end catch
end
go

Create procedure UpdateContratante
(
	@id int, @nome varchar(200), @login varchar(30), @senha varchar(20), @email varchar(100), @telefone varchar(14), @qtdProjetos int, @mediaNota decimal(2,1),
	@status int, 
	@areaAtuacao text, @descrContratante text
)

as
begin
    begin try
    begin tran
		update pessoa set nome = @nome, login = @login, senha = @senha, email = @email, telefone = @telefone, qtdProjetos = @qtdProjetos, mediaNota = @mediaNota,
		status = @status where id = @id
        update contratante set areaAtuacao = @areaAtuacao, descrContratante = @descrContratante where contratante_id = @id
        commit
    end try
    begin catch
        rollback
    end catch
end
go

create procedure AddContrato
(
	@descricao text, @status int, @notaContratante int, @notaFreelancer int, @id int
)

as
begin
    begin try
    begin tran
        insert into contrato(dataContrato, descricao, status, notaContratante, notaFreelancer, contratante_id) 
		values(GETDATE(), @descricao, @status, @notaContratante, @notaFreelancer, @id) 
        commit
    end try
    begin catch
        rollback
    end catch
end
go

 

