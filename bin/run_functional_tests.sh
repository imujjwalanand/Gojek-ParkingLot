arg1=$1
cd "./../src/Gojek.parking_lot"
dotnet restore
dotnet build
dotnet test --no-restore
sleep 10s