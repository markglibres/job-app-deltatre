#!/bin/bash
if [[ "$*" != '--skip-build' ]]
then
    sh ./build.sh
fi

SCRIPT_DIR=$(pwd)
BACKEND_DIR=$SCRIPT_DIR/backend/DeltaTre.Search.Presentation.Rpc
FRONTEND_DIR=$SCRIPT_DIR/frontend/DeltaTre.Presentation.Api

trap 'kill $(jobs -p)' INT

dotnet run --no-build -p $BACKEND_DIR &
dotnet run --no-build -p $FRONTEND_DIR &
wait
