var ChallengeController = function (serviceContext) {
    this.RenderPage = function () {
        var allChallenges = serviceContext.ChallengeService().ReadAll();

        for (var i = 0; i < allChallenges.length; i++) {
            var challenges = new ChallengeGrid("card-challenges", allChallenges[i]);
            challenges.RenderGridImage();
        }
    }
}