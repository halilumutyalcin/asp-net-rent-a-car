create table cars(
	id int not null primary key identity,
	plaka nvarchar(50) not null unique,
	marka nvarchar(50) not null,
	model nvarchar(50) not null,
	renk nvarchar(50) not null,
)

insert into cars(plaka,marka,model,renk) values
('34ABC123','Mercedes Benz','E320','Beyaz'),
('34ABC456','Audi','A6','Siyah'),
('34ABC789','Audi','RS6','Kırmızı'),
('34XYZC123','BMW','M5','Gri')