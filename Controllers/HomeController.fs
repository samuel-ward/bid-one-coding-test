namespace bid_one_coding_test.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.Diagnostics
open JsonFlatFileDataStore

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

open bid_one_coding_test.Models

type HomeController (logger : ILogger<HomeController>) =
    inherit Controller()

    // TODO: Wrap C# operation in try{}
    let people () =
        // We would inject a DB through the dependency injection here, rather than use a JSON file
        (new DataStore("data.json")).GetCollection<Person>()

    member this.Index () =
        // View all current people added
        (people ()).AsQueryable()
        |> this.View

    member this.Create () =
        // View to create a new person record
        this.View ()

    [<HttpPost>]
    member this.Create (person: Person): ActionResult =
        if base.ModelState.IsValid then
            person |> (people ()).InsertOneAsync |> Async.AwaitTask |> Async.RunSynchronously
            this.RedirectToAction("Index")
        else
        person
        |> this.View :> ActionResult

    [<ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)>]
    member this.Error () =
        let reqId = 
            if isNull Activity.Current then
                this.HttpContext.TraceIdentifier
            else
                Activity.Current.Id

        this.View({ RequestId = reqId })