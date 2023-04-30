create table carstore(
	id int not null unique,
	plaka nvarchar(50) not null unique,
	marka nvarchar(50) not null,
	model nvarchar(50) not null,
	renk nvarchar(50) not null,
)

insert into carstore(id,plaka,marka,model,renk) values
(1,'34ABC123','Mercedes Benz','E320','Beyaz'),
(2,'34ABC456','Audi','A6','Siyah'),
(3,'34ABC789','Audi','RS6','Kırmızı'),
(4,'34XYZC123','BMW','M5','Gri')