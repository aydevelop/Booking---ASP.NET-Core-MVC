watch:
	dotnet watch run --project Booking

db-del:
	dotnet ef database drop -p Booking.DAL -s Booking
	
db-upd:
	dotnet ef database update -p Booking.DAL -s Booking	

db-mgr:
	dotnet ef migrations add $(n) -p Booking.DAL -s Booking

db-mgr-del:
	dotnet ef migrations remove -p Booking.DAL -s Booking 

all : clean restore build

clean:
	dotnet clean

restore:
	dotnet restore

build: 
	dotnet build