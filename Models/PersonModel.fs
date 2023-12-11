namespace bid_one_coding_test.Models

open System
open System.ComponentModel.DataAnnotations

type Person () =
    [<Key>] member val Id = Guid.NewGuid() with get, set
    [<Required>] member val FirstName = "" with get, set
    [<Required>] member val LastName = "" with get, set