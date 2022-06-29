#!/bin/sh
mono nuget.exe pack ImageEdit.Plugin.nuspec -verbosity detailed -basepath ./ -OutputDirectory ./dist
