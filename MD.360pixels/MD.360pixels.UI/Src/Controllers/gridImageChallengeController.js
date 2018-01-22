var ChallengeGrid = function (containerID, challenges) {

    this.RenderGridImage = function () {
        //var jqGrid = $("<div class='card'>")
        //        .append("<img id='photo-cat' class='card-img-top' style='max-width:444px; max-height:296px; ' src='" + challenges.Image+"' alt='Card image cap'>")
        //        .append(" <div class='card-body'>")
        //            .append("h5 class='card-title' style='text-align:center;'> " + challenges.Name + "</h5>")
        //$('#' + containerID).append(jqGrid);

        var jqCard = $("<div class='card' style='width: 18rem;'>")
            //.append("<div id='" + challenges.Id + "'class='card'>")
            .append("<img id='photo-cat' class='card-img-top' style='max-width:444px; max-height:296px;' onclick='showGridChallenge()' src='" + challenges.Image+"' alt='Card image cap'>")
            .append("<h4 class='card-title'>" +challenges.Name + "</h4>")
           
        $('#' + containerID).append(jqCard);
    }
}