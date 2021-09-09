module Tests

open GameOfLife
open Xunit
open FsUnit.Xunit
open FsUnit.CustomMatchers

[<Fact>]
let ``Game can be started`` () =
    Game.Start(
        [ Game.CreateLivingCell({ X = 2; Y = 2 }) ])

[<Fact>]
let ``Can create a living cell`` () =
    let cell = Game.CreateLivingCell({ X = 2; Y = 2 })
    
    cell |> should be (ofCase<@Game.Living@>)
    
[<Fact>]
let ``Can create a dead cell`` () =
    let cell = Game.CreateDeadCell({ X = 2; Y = 2 })
    
    cell |> should be (ofCase<@Game.Dead@>)

[<Fact>]
let ``Dead cell has one neighbour`` () =
    let game = Game.Start [ Game.CreateLivingCell({ X = 1; Y = 2 })
                            Game.CreateLivingCell({ X = 2; Y = 2 })]
    
    Game.NumberOfNeighbours game { X = 1; Y = 2 } |> should equal 1
[<Fact>]
let ``Dead cell has two neighbours`` () =
    let game = Game.Start [ Game.CreateLivingCell({ X = 1; Y = 2 })
                            Game.CreateLivingCell({ X = 2; Y = 2 })
                            Game.CreateLivingCell({ X = 2; Y = 1 })]
    
    Game.NumberOfNeighbours game { X = 2; Y = 2 } |> should equal 2