#!/bin/sh

if [ "$(dirname $0)" = "." ]
then
    cd ../src/balasolu
else
    parent=$(dirname $(dirname "$0"))
    cd "$parent"/src/balasolu
fi
dotnet ef database drop --force --context KeyDbContext
for file in ./migrations/*
do
	if [[ "$file" = *Global* || "$file" = *Designer* || "$file" = *Snapshot* ]]
	then
		continue
	fi
	dotnet ef migrations remove --context KeyDbContext
done
dotnet ef migrations add init --context KeyDbContext
