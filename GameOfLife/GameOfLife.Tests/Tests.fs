module Tests

open System
open GameOfLife
open Xunit

[<Fact>]
let ``Game can be started`` () =
    Game.Start()