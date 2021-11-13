#!/bin/sh

parent=$(dirname $(dirname "$0"))
cd "$parent"/src/balasolu.web
dotnet ef database drop --force
for file in ./Migrations/*
do
	if [[ "$file" = *Global* || "$file" = *Designer* ]]
	then
		continue
	fi
	dotnet ef migrations remove
done
dotnet ef migrations add init
