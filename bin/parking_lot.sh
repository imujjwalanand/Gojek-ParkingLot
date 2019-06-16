arg1=$1
cd "./../src/parking_lot"
cd "parking_lot"

dotnet build

if [ -z "$1" ] ; then
        dotnet run
        exit 1

else
	dotnet run $arg1

fi

sleep 10s