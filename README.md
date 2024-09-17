### Set environment variable
export ALLURE_CONFIG=<b>[path to allureConfig.json file]</b>

### Run tests
dotnet test -v normal

### Generate report
allure generate <b>[path to allure-results folder]</b> -o  report --clean

### Open report
allure open report