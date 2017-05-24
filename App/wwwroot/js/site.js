var AdminChangeWindowNameSpace =
{
    MealClick: function ()
    {
        document.getElementById("diet").style.display = "none";
        document.getElementById("meal").style.display = "block";
    },
    MealDayClick: function ()
    {
        document.getElementById("diet").style.display = "block";
        document.getElementById("meal").style.display = "none";
    }
}