module Program = let [<EntryPoint>] main _ =
    
    let (someString : string option) = Some "Anders"
    
    someString
    |> Option.map System.Console.WriteLine
    ()
