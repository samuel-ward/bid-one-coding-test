namespace bid_one_coding_test.Models

open System
open System.ComponentModel.DataAnnotations

type Person () =
    [<Required(AllowEmptyStrings=false)>] member val Id = Guid.NewGuid().ToString() with get, set
    [<Required(AllowEmptyStrings=false)>] member val FirstName = "" with get, set
    [<Required(AllowEmptyStrings=false)>] member val LastName = "" with get, set