#!/bin/sh

if [ "$(dirname $0)" = "." ]
then
    cd ../src/balasolu
else
    parent=$(dirname $(dirname "$0"))
    cd "$parent"/src/balasolu
fi

date=$(date '+%H-%M-%S_%d-%m-%Y')

dotnet ef migrations add _"$date" --context DefaultDbContext
