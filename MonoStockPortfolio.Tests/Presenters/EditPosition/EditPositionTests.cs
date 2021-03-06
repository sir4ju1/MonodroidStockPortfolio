using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Machine.Specifications;
using MonoStockPortfolio.Activites.EditPositionScreen;
using MonoStockPortfolio.Core.PortfolioRepositories;
using MonoStockPortfolio.Core.StockData;
using Telerik.JustMock;

namespace MonoStockPortfolio.Tests.Presenters.EditPosition
{
    public class EditPositionTests
    {
        protected static EditPositionPresenter _presenter;
        protected static IPortfolioRepository _mockPortfolioRepository;
        protected static IStockDataProvider _mockStockService;
        protected static IEditPositionView _mockView;

        Establish context = () =>
            {
                _mockPortfolioRepository = Mock.Create<IPortfolioRepository>();
                _mockStockService = Mock.Create<IStockDataProvider>();
                _mockView = Mock.Create<IEditPositionView>();

                _presenter = new EditPositionPresenter(_mockPortfolioRepository, _mockStockService);
            };

        protected static void MockPositionMatches(Expression<Predicate<IList<string>>> match)
        {
            Mock.Assert(() => _mockView.ShowErrorMessages(Arg.Matches(match)), Occurs.Exactly(1));
        }
    }
}