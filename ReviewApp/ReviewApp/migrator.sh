#!/bin/bash

dotnet ef database update --context MainDbContext
dotnet ef database update --context SecurityDbContext

exit 0
