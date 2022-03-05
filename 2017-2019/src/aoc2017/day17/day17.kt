package aoc2017.day17

import common.measure

const val input = 335  // number of steps to do before inserting

fun main(args: Array<String>) {
    val current1 = measure { emulateSpinLock(input, 2017) }
    println(">>>  PART 1:  ${current1.next.number}")

    // part 2 took 447 seconds to execute; not bad but can be better probably
    var current2 = measure { emulateSpinLock(input, 50_000_000) }
    while (current2.number != 0) current2 = current2.next
    println(">>>  PART 2:  ${current2.next.number}")
}

fun emulateSpinLock(stepsPerTraversal: Int, traversalsCount: Int): Item {
    var current = Item(0)

    for (i in 1..traversalsCount) {
        for (x in 1..stepsPerTraversal) current = current.next
        // insert new item
        val new = Item(i, current.next)
        current.next = new
        // move current position to point to it
        current = new
    }

    return current
}

data class Item(val number: Int) {
    constructor(number: Int, next: Item) : this(number) {
        this.next = next
    }
    var next: Item = this
}




//// instead of GetInnerRequest() in the request class:
//internal GetHttpRequest(object DefaultContent, Dictionary<string, string> QueryString)
//{
//    var AllQuerystringsFormatted = _QueryString.Concat(QueryString)...;
//    WithHeader(Constants.RELAY_QUERY_STRING, AllQuerystringsFormatted);
//    _Content = _Content ?? DefaultContent ?? new { };
//    InnerRequest.Content = new HttpContent(_Content, new JsonMediaFormatter())
//    return InnerRequest;
//}
//
//// then in the relay class:
//public Task<HttpResponseMessage> Send(IRestfulRequest RestfulRequestIn)
//{
//    AddAuth(RestfulRequest);
//    var RestfulRequest = RestfulRequestIn as OnlineServicesRestfulRequest;
//    if (RestfulRequest == null) throw...;
//    var HttpRequest = RestfulRequest.InnerRequest;
//    EnsureServiceNameAndFunctionNameAreSet(RestfulRequest); // or whatever it looked like
//    return _Client.SendAsync(HttpRequest);
//}