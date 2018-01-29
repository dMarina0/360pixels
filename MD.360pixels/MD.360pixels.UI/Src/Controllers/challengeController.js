var ChallengeController = function (serviceContext) {

    this.RenderPage = function ()
    {
        serviceContext.ChallengeService().ReadAll(function (allChallenges) {
            for (var i = 0; i < allChallenges.length; i++) {
                var challenges = new ChallengeGrid("card-challenges", allChallenges[i]);
                challenges.RenderGridImage();
            }
        });
    }
}