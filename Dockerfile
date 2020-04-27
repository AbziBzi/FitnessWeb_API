FROM mcr.microsoft.com/dotnet/core/sdk:3.1
COPY /bin/Release/netcoreapp3.1/ /app

WORKDIR /app
RUN dotnet dev-certs https
EXPOSE 5000:5000

ENTRYPOINT ["dotnet", "FitnessWeb_API.dll"]