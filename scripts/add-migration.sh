#!/bin/sh

parent=$(dirname $(dirname "$0"))
cd "$parent"/src/balasolu.web
date=$(date '+%H-%M-%S_%d-%m-%Y')
dotnet ef migrations add _"$date"
