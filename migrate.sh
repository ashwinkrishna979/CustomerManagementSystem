#!/bin/bash

# Change directory to the specified location
cd CMS.Data/Context

# Run the dotnet ef migrations add command
dotnet ef migrations add DockerInitial -c CMSDBContext --startup-project ../../CMS.Web -p ../../CMS.Data

dotnet ef database update -c CMSDBContext --startup-project ../../CMS.Web -p ../../CMS.Data