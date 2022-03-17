var csharp = {
    StartAudio: function(station) {
        start_sound(station);
    },

    StopAudio: function() {
        stop_sound();
    },

    GetTemperature: function(station_id){
        var temp = getTemp(station_id);
        return temp;
    }
}

mergeInto(LibraryManager.library, csharp);