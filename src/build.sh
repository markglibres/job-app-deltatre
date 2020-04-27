#!/bin/bash
SCRIPT_DIR=$(pwd)
BACKEND_DIR=$SCRIPT_DIR/backend/DeltaTre.Search.Presentation.Rpc
FRONTEND_DIR=$SCRIPT_DIR/frontend/DeltaTre.Presentation.Api

find . -type d -name "*.Tests" -print0 | xargs -0 -L1 sh -c 'dotnet test "$0"'

cd $BACKEND_DIR
dotnet restore
dotnet build

cd $FRONTEND_DIR
dotnet restore
dotnet build
