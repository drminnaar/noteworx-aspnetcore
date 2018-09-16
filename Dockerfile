FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
RUN apt-get update && \
   apt-get upgrade -y && \
   curl -sL https://deb.nodesource.com/setup_8.x | bash - && \
   apt-get install -y nodejs && \
   apt-get install -y build-essential && \
   rm -rf /var/lib/apt/lists/ && \
   npm install -g gulp
WORKDIR /src
COPY . .
WORKDIR /src/NoteWorx.Web
RUN npm install \
   && dotnet restore \
   && dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NoteWorx.Web.dll"]