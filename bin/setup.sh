arg1=$1
cd "./../src/parking_lot"
dotnet restore
dotnet build
dotnet test --no-restore
cd "parking_lot"

if [ -z "$1" ] ; then
        dotnet run
        exit 1

else
	dotnet run $arg1

fi

sleep 10s