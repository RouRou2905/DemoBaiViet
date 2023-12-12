use QuanLyBaiViet
drop table post


create table post(
	id int identity primary key not null,
	title nvarchar(max) not null,
	content nvarchar(max) not null,
	script nvarchar(max) not null,
	category nvarchar(50) not null,
	img ntext,
	DateCreate ntext,
	isDelete tinyint,
	DeleteTime ntext
)

create table post(
	id int identity primary key not null,
	title nvarchar(max) not null,
	content nvarchar(max) not null,
	script nvarchar(max) not null,
	category nvarchar(50) not null,
	imgName ntext,
	imgFile ntext,
	DateCreate ntext,
	isDelete tinyint,
	DeleteTime ntext
)

select * from post