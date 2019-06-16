arg1=$1
cd "./../src/parking_lot"
dotnet restore
dotnet build
dotnet test --no-restore
sleep 10s