using TollFeeCalculator.Common.Interfaces;

namespace TollFeeCalculator.Models.TollFreeDate;

public class TollFreeDate : IIsTollFreeDate
{
    private readonly DateTime _tollFreeDate;
    private readonly DateTime _dayBeforeTollFreeDate;

    public TollFreeDate(DateTime tollFreeDate)
    {
        _tollFreeDate = tollFreeDate;
        _dayBeforeTollFreeDate = _tollFreeDate.AddDays(-1);
    }

    public bool IsTollFreeDate(DateTime date) => date.Date == _tollFreeDate.Date || date.Date == _dayBeforeTollFreeDate.Date;
}