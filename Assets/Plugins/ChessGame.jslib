mergeInto(LibraryManager.library, {

    UnityGetMyColor : function () {
        unityGetMyColor();
    },

    squareClick: function (tileName, thisName, notation) {
    unityGetPlayerGameObject(Pointer_stringify(tileName), Pointer_stringify(thisName), Pointer_stringify(notation));
    },

    GetPlayerData : function () {
        unityGetPlayerData();
    },

    GetOnlinePlayers : function () {
        unityListOnline();
    },

    GetImage : function (email) {
        unityRequestPlayerImage(Pointer_stringify(email));
    },

    inviPlayer : function (email, type) {
        unityInvitePlayer(Pointer_stringify(email), Pointer_stringify(type));
    },

    Reply : function (reply, email) {
        unityInvitationResponse(Pointer_stringify(reply), Pointer_stringify(email));
    },

    promotion: function (PieceNotation, square) {
        unitySetPromotion(Pointer_stringify(PieceNotation), Pointer_stringify(square));
    },

    resign : function (enemyEmail) {
        unityInvitationResponse(Pointer_stringify(enemyEmail));
    },

    checkmate : function (email, color) {
        unityPlayerCheckmate(Pointer_stringify(email), Pointer_stringify(color));
    }


});