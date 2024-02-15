#!/bin/bash
echo '----------Testing API------------------------'
echo '----------Testing API------------------------'
echo '----------Testing API------------------------'
echo '----------Testing API------------------------'
echo '----------Testing API------------------------'

dotnet test ../app/test/HotelAPI.Tests/HotelAPI.Tests.csproj

echo '----------Building API------------------------'
echo '----------Building API------------------------'
echo '----------Building API------------------------'
echo '----------Building API------------------------'
echo '----------Building API------------------------'

dotnet build ../app/src/app.csproj

echo '----------Running API------------------------'
echo '----------Running API------------------------'
echo '----------Running API------------------------'
echo '----------Running API------------------------'
echo '----------Running API------------------------'

dotnet run --project ../app/src/app.csproj

exit