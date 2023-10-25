BeepLearningCenter is a .NET console application

## Publish the App
`dotnet publish`

# Usage

There are two CLI arguments, both required.

- --host
  - The IP of the Epic to beep
- --duration
  - How long in milliseconds to maintain the beep

Navigate to the published `.dll` or 'exe' and run

```.\BeepLearningCenter --host 10.0.2.13 --duration 500```