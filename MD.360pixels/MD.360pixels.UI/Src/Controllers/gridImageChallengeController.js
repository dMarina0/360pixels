var ChallengeGrid = function (containerID, challenges) {

    this.RenderGridImage = function () {
        var jqCard = $("<div class='card' style='width: 18rem;'>")
            .append("<img id='photo-cat' class='card-img-top' style='max-width:444px; max-height:296px;' onclick='showGridChallenge()' src='" + challenges.Description+"' alt='Card image cap'>")
            .append("<h4 class='card-title'>" +challenges.ChallengeName + "</h4>")
           
        $('#' + containerID).append(jqCard);
    }
}