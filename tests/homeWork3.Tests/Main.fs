module hw3.Tests

open Expecto

let config = { FsCheckConfig.defaultConfig with maxTest = 1000 }

[<EntryPoint>]
let main argv = Tests.runTestsInAssembly defaultConfig argv
