namespace SPbU_hometask


module ExpectoTemplate =
    open Expecto
    open Tests
    
    [<EntryPoint>]
    let main argv = Tests.runTestsInAssembly defaultConfig argv
