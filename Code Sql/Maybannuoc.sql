create database maybanuoc
use maybanuoc
go

create table Account
(
	Username NVARCHAR (100) PRIMARY KEY ,
	Password NVARCHAR (100) DEFAULT 0

)
go
create table May
(
	id int identity primary key,
	name nvarchar(100)
)

alter table May add DoanhThu int Default 0 with values
create table Drink
(
	idD INT IDENTITY PRIMARY KEY,
	name NVARCHAR (100),
	price INT,
	soluong int,
	idM int
	foreign key (idM) references dbo.May
)

create table Bill
(
	id int identity primary key,
	Datecheckout DATE,
	idDrink int not null,
	sl int not null,
	
	FOREIGN KEY (idDrink) References dbo.Drink(idD)
)

insert into dbo.Account
( Username,
 Password)
VALUES (N'Tungduong',
	N'duongnguyen'
	)

insert into dbo.Account
(Username,
Password)

VALUES (N'admin',
N'admin')
SELECT * FROM dbo.Account
insert into dbo.Account
(Username,
Password)

VALUES(N'Duchuong',
N'huong123')


CREAte PROC USP_Login
@username Nvarchar(100), @password nvarchar(100)
as 
begin
 SELECT * FROM dbo.Account WHERE Username = @username and Password = @password 
end
go

insert into dbo.May
(name)
values (N'Máy 1')
insert into dbo.May
(name)
values (N'Máy 2')

select * from dbo.May

Insert into dbo.Drink
(name, price, soluong,idM)
Values (N'C2',N'8000',N'10',N'1')

Insert into dbo.Drink
(name, price, soluong,idM)
Values (N'Sting đỏ',N'12000',N'10',N'1')

Insert into dbo.Drink
(name, price, soluong,idM)
Values (N'Sting vàng',N'11000',N'10',N'1')

Insert into dbo.Drink
(name, price, soluong,idM)
Values (N'Red Bull',N'15000',N'10',N'1')

Insert into dbo.Drink
(name, price, soluong,idM)
Values (N'Doctor Thanh',N'5000',N'10',N'1')

Insert into dbo.Drink
(name, price, soluong,idM)
Values (N'Aquafina',N'10000',N'10',N'1')

Insert into dbo.Drink
(name, price, soluong,idM)
Values (N'Sữa milo',N'8000',N'10',N'2')

Insert into dbo.Drink
(name, price, soluong,idM)
Values (N'Sữa CGHN',N'8000',N'10',N'2')

insert into Drink Values
(N'Trà Xanh 0 Độ',12000,10,2)

Insert into dbo.Drink
(name, price, soluong,idM)
Values (N'Sữa Mộc Châu',N'12000',N'10',N'2')

insert into Drink Values
(N'Nescafe Latte',8000,10,1)
insert into Drink Values
(N'CocaCola',7000,10,1)
insert into Drink Values
(N'TwisTer',10000,15,2)
insert into Drink Values
(N'Pepsi',8000,15,2)
insert into Drink Values
(N'7 Up',9000,13,2)
insert into Drink Values
(N'StrongBow',25000,15,2)
insert into Drink Values
(N'Mirinda',11000,15,1)

insert into Drink Values
(N'Mirinda Cam',12000,15,2)


select * from dbo.Drink


insert into dbo.Bill
(Datecheckout,idDrink,sl)
VALUES(GETDATE(),1,2)

insert into dbo.Bill
(Datecheckout,idDrink,sl)
VALUES(GETDATE(),3,4)

insert into dbo.Bill
(Datecheckout,idDrink,sl)
VALUES(GETDATE(),5,6)

insert into dbo.Bill
(Datecheckout,idDrink,sl)
VALUES(GETDATE(),2,8)

insert into dbo.Bill
(Datecheckout,idDrink,sl)
VALUES(GETDATE(),2,2)

insert into dbo.Bill
(Datecheckout,idDrink,sl)
VALUES(GETDATE(),9,3)


create proc USP_InserBill
@idDrink int, @sl int
as	
begin
insert dbo.Bill
			(Datecheckout,
			idDrink,
			sl
			)
	Values( GETDATE(),
			@idDrink,
			@sl
			)
END



create proc USP_GetListBillM1
@datea date, @dateb date
as
begin

	select Datecheckout as NgàyMua,d.name As TênĐồUống,sl as SốLượng,price as Giá,sl*price as TổngTiền 
	from Bill as b,Drink as d , May as m 
	where d.idD=b.idDrink and d.idM =m.id and m.id=1
	and Datecheckout >= @datea and Datecheckout <= @dateb

end
go

create proc USP_GetListBillM2
@datec date, @dated date
as
begin

	select Datecheckout as NgàyMua,d.name As TênĐồUống,sl as SốLượng,price as Giá,sl*price as TổngTiền 
	from Bill as b,Drink as d , May as m 
	where d.idD=b.idDrink and d.idM =m.id and m.id=2
	and Datecheckout >= @datec and Datecheckout <= @dated

end
go



create proc USP_GetListBillM1Day
@dateD date
as
begin
select  d.name As TênĐồUống, sum(sl) as SốLượng from Bill as b
inner join Drink as d on b.idDrink= d.idD
inner join May as m on m.id = d.idM
where m.id =1 and b.Datecheckout = @dateD
group by d.name
end


create proc USP_GetListBillM2Day
@dateD date
as
begin
select  d.name As TênĐồUống, sum(sl) as SốLượng from Bill as b
inner join Drink as d on b.idDrink= d.idD
inner join May as m on m.id = d.idM
where m.id =2 and b.Datecheckout = @dateD
group by d.name
end


create proc USP_DoanhThuSP1
@datec date,@dated date
as 
begin
select d.name as ĐồUống,sum(b.sl)as SốLượng,d.price as Giá,d.price*sum(b.sl) as TổngTiền from Bill as b, Drink as d,May as m
where d.idD=b.idDrink and d.idM = m.id and m.id =1
and Datecheckout >= @datec and Datecheckout <= @dated
group by d.name,d.price
end

create proc USP_DoanhThuSP2
@datec date,@dated date
as 
begin
select d.name as ĐồUống,sum(b.sl)as SốLượng,d.price as Giá,d.price*sum(b.sl) as TổngTiền from Bill as b, Drink as d,May as m
where d.idD=b.idDrink and d.idM = m.id and m.id =2
and Datecheckout >= @datec and Datecheckout <= @dated
group by d.name,d.price
end


DBCC CHECKIDENT(Drink, RESEED, 16)

DBCC CHECKIDENT(Drink, NORESEED)

select * from Drink
