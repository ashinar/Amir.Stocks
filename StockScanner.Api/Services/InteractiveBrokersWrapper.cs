using IBApi;
using IBApi.protobuf;
using System.Diagnostics;

namespace StockScanner.Api.Services
{
    public class InteractiveBrokersWrapper : EWrapper
    {
        private TaskCompletionSource<bool> _connectionTcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public Task ConnectionTask => _connectionTcs.Task;


        public void ResetConnection()
        {
            _connectionTcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
        }

        public void nextValidId(int orderId)
        {
            Console.WriteLine($"Connected to IB. Next Order ID: {orderId}");
            _connectionTcs.TrySetResult(true);
        }

        public void error(Exception e)
        {
            Console.WriteLine($"IB Error: {e.Message}");
        }

        public void error(string str)
        {
            Console.WriteLine($"IB Error: {str}");
        }

        public void error(int id, long errorTime, int errorCode, string errorMsg, string advancedOrderRejectJson)
        {
            Console.WriteLine($"IB Error - Id: {id}, Code: {errorCode}, Message: {errorMsg}");
        }

        public void currentTime(long time)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickPrice(int tickerId, int field, double price, TickAttrib attribs)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickSize(int tickerId, int field, decimal size)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickString(int tickerId, int field, string value)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickGeneric(int tickerId, int field, double value)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureLastTradeDate, double dividendImpact, double dividendsToLastTradeDate)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void deltaNeutralValidation(int reqId, IBApi.DeltaNeutralContract deltaNeutralContract)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickOptionComputation(int tickerId, int field, int tickAttrib, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickSnapshotEnd(int tickerId)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void managedAccounts(string accountsList)
        {
            Console.WriteLine($"IB: managedAccounts = {accountsList}");
        }

        public void connectionClosed()
        {
            Console.WriteLine("IB connection closed.");
        }

        public void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void accountSummaryEnd(int reqId)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void bondContractDetails(int reqId, IBApi.ContractDetails contract)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updateAccountValue(string key, string value, string currency, string accountName)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updatePortfolio(IBApi.Contract contract, decimal position, double marketPrice, double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updateAccountTime(string timestamp)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void accountDownloadEnd(string account)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void orderStatus(int orderId, string status, decimal filled, decimal remaining, double avgFillPrice, long permId, int parentId, double lastFillPrice, int clientId, string whyHeld, double mktCapPrice)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void openOrder(int orderId, IBApi.Contract contract, IBApi.Order order, IBApi.OrderState orderState)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void openOrderEnd()
        {
            Console.WriteLine("IB: openOrderEnd");
        }

        public void contractDetails(int reqId, IBApi.ContractDetails contractDetails)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void contractDetailsEnd(int reqId)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void execDetails(int reqId, IBApi.Contract contract, IBApi.Execution execution)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void execDetailsEnd(int reqId)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void commissionAndFeesReport(IBApi.CommissionAndFeesReport commissionAndFeesReport)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalData(int reqId, Bar bar)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalDataUpdate(int reqId, Bar bar)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalDataEnd(int reqId, string start, string end)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void marketDataType(int reqId, int marketDataType)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updateMktDepth(int tickerId, int position, int operation, int side, double price, decimal size)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, decimal size, bool isSmartDepth)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updateNewsBulletin(int msgId, int msgType, string message, string origExchange)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void position(string account, IBApi.Contract contract, decimal pos, double avgCost)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void positionEnd()
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void realtimeBar(int reqId, long date, double open, double high, double low, double close, decimal volume, decimal WAP, int count)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void scannerParameters(string xml)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void scannerData(int reqId, int rank, IBApi.ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void scannerDataEnd(int reqId)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void receiveFA(int faDataType, string faXmlData)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void verifyMessageAPI(string apiData)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void verifyCompleted(bool isSuccessful, string errorText)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void verifyAndAuthMessageAPI(string apiData, string xyzChallenge)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void verifyAndAuthCompleted(bool isSuccessful, string errorText)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void displayGroupList(int reqId, string groups)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void displayGroupUpdated(int reqId, string contractInfo)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void connectAck()
        {
            Console.WriteLine("IB Connect ACK");
        }

        public void positionMulti(int requestId, string account, string modelCode, IBApi.Contract contract, decimal pos, double avgCost)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void positionMultiEnd(int requestId)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void accountUpdateMulti(int requestId, string account, string modelCode, string key, string value, string currency)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void accountUpdateMultiEnd(int requestId)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void securityDefinitionOptionParameter(int reqId, string exchange, int underlyingConId, string tradingClass, string multiplier, HashSet<string> expirations, HashSet<double> strikes)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void securityDefinitionOptionParameterEnd(int reqId)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void softDollarTiers(int reqId, IBApi.SoftDollarTier[] tiers)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void familyCodes(IBApi.FamilyCode[] familyCodes)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void symbolSamples(int reqId, IBApi.ContractDescription[] contractDescriptions)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void mktDepthExchanges(DepthMktDataDescription[] depthMktDataDescriptions)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickNews(int tickerId, long timeStamp, string providerCode, string articleId, string headline, string extraData)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void smartComponents(int reqId, Dictionary<int, KeyValuePair<string, char>> theMap)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickReqParams(int tickerId, double minTick, string bboExchange, int snapshotPermissions)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void newsProviders(IBApi.NewsProvider[] newsProviders)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void newsArticle(int requestId, int articleType, string articleText)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalNews(int requestId, string time, string providerCode, string articleId, string headline)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalNewsEnd(int requestId, bool hasMore)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void headTimestamp(int reqId, string headTimestamp)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void histogramData(int reqId, HistogramEntry[] data)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void rerouteMktDataReq(int reqId, int conId, string exchange)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void rerouteMktDepthReq(int reqId, int conId, string exchange)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void marketRule(int marketRuleId, IBApi.PriceIncrement[] priceIncrements)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void pnl(int reqId, double dailyPnL, double unrealizedPnL, double realizedPnL)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void pnlSingle(int reqId, decimal pos, double dailyPnL, double unrealizedPnL, double realizedPnL, double value)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalTicks(int reqId, IBApi.HistoricalTick[] ticks, bool done)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalTicksBidAsk(int reqId, IBApi.HistoricalTickBidAsk[] ticks, bool done)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalTicksLast(int reqId, IBApi.HistoricalTickLast[] ticks, bool done)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickByTickAllLast(int reqId, int tickType, long time, double price, decimal size, IBApi.TickAttribLast tickAttribLast, string exchange, string specialConditions)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickByTickBidAsk(int reqId, long time, double bidPrice, double askPrice, decimal bidSize, decimal askSize, IBApi.TickAttribBidAsk tickAttribBidAsk)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickByTickMidPoint(int reqId, long time, double midPoint)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void orderBound(long permId, int clientId, int orderId)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void completedOrder(IBApi.Contract contract, IBApi.Order order, IBApi.OrderState orderState)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void completedOrdersEnd()
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void replaceFAEnd(int reqId, string text)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void wshMetaData(int reqId, string dataJson)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void wshEventData(int reqId, string dataJson)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalSchedule(int reqId, string startDateTime, string endDateTime, string timeZone, IBApi.HistoricalSession[] sessions)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void userInfo(int reqId, string whiteBrandingId)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void currentTimeInMillis(long timeInMillis)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void orderStatusProtoBuf(IBApi.protobuf.OrderStatus orderStatusProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void openOrderProtoBuf(OpenOrder openOrderProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void openOrdersEndProtoBuf(OpenOrdersEnd openOrdersEndProto)
        {
            Console.WriteLine("IB: openOrdersEndProtoBuf");

        }

        public void errorProtoBuf(ErrorMessage errorMessageProto)
        {
            Console.WriteLine($"IB ERROR: {errorMessageProto}");
        }

        public void execDetailsProtoBuf(ExecutionDetails executionDetailsProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void execDetailsEndProtoBuf(ExecutionDetailsEnd executionDetailsEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void completedOrderProtoBuf(CompletedOrder completedOrderProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void completedOrdersEndProtoBuf(CompletedOrdersEnd completedOrdersEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void orderBoundProtoBuf(OrderBound orderBoundProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void contractDataProtoBuf(ContractData contractDataProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void bondContractDataProtoBuf(ContractData contractDataProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void contractDataEndProtoBuf(ContractDataEnd contractDataEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickPriceProtoBuf(TickPrice tickPriceProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickSizeProtoBuf(TickSize tickSizeProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickOptionComputationProtoBuf(TickOptionComputation tickOptionComputationProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickGenericProtoBuf(TickGeneric tickGenericProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickStringProtoBuf(TickString tickStringProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickSnapshotEndProtoBuf(TickSnapshotEnd tickSnapshotEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updateMarketDepthProtoBuf(MarketDepth marketDepthProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updateMarketDepthL2ProtoBuf(MarketDepthL2 marketDepthL2Proto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void marketDataTypeProtoBuf(MarketDataType marketDataTypeProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickReqParamsProtoBuf(TickReqParams tickReqParamsProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updateAccountValueProtoBuf(AccountValue accountValueProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updatePortfolioProtoBuf(PortfolioValue portfolioValueProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updateAccountTimeProtoBuf(AccountUpdateTime accountUpdateTimeProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void accountDataEndProtoBuf(AccountDataEnd accountDataEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void managedAccountsProtoBuf(ManagedAccounts managedAccountsProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void positionProtoBuf(Position positionProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void positionEndProtoBuf(PositionEnd positionEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void accountSummaryProtoBuf(AccountSummary accountSummaryProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void accountSummaryEndProtoBuf(AccountSummaryEnd accountSummaryEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void positionMultiProtoBuf(PositionMulti positionMultiProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void positionMultiEndProtoBuf(PositionMultiEnd positionMultiEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void accountUpdateMultiProtoBuf(AccountUpdateMulti accountUpdateMultiProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void accountUpdateMultiEndProtoBuf(AccountUpdateMultiEnd accountUpdateMultiEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalDataProtoBuf(HistoricalData historicalDataProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalDataUpdateProtoBuf(HistoricalDataUpdate historicalDataUpdateProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalDataEndProtoBuf(HistoricalDataEnd historicalDataEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void realTimeBarTickProtoBuf(RealTimeBarTick realTimeBarTickProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void headTimestampProtoBuf(HeadTimestamp headTimestampProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void histogramDataProtoBuf(HistogramData histogramDataProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalTicksProtoBuf(HistoricalTicks historicalTicksProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalTicksBidAskProtoBuf(HistoricalTicksBidAsk historicalTicksBidAskProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalTicksLastProtoBuf(HistoricalTicksLast historicalTicksLastProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickByTickDataProtoBuf(TickByTickData tickByTickDataProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updateNewsBulletinProtoBuf(NewsBulletin newsBulletinProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void newsArticleProtoBuf(NewsArticle newsArticleProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void newsProvidersProtoBuf(NewsProviders newsProvidersProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalNewsProtoBuf(HistoricalNews historicalNewsProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalNewsEndProtoBuf(HistoricalNewsEnd historicalNewsEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void wshMetaDataProtoBuf(WshMetaData wshMetaDataProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void wshEventDataProtoBuf(IBApi.protobuf.WshEventData wshEventDataProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void tickNewsProtoBuf(TickNews tickNewsProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void scannerParametersProtoBuf(ScannerParameters scannerParametersProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void scannerDataProtoBuf(ScannerData scannerDataProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void pnlProtoBuf(PnL pnlProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void pnlSingleProtoBuf(PnLSingle pnlSingleProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void receiveFAProtoBuf(ReceiveFA receiveFAProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void replaceFAEndProtoBuf(ReplaceFAEnd replaceFAEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void commissionAndFeesReportProtoBuf(IBApi.protobuf.CommissionAndFeesReport commissionAndFeesReportProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void historicalScheduleProtoBuf(HistoricalSchedule historicalScheduleProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void rerouteMarketDataRequestProtoBuf(RerouteMarketDataRequest rerouteMarketDataRequestProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void rerouteMarketDepthRequestProtoBuf(RerouteMarketDepthRequest rerouteMarketDepthRequestProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void secDefOptParameterProtoBuf(SecDefOptParameter secDefOptParameterProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void secDefOptParameterEndProtoBuf(SecDefOptParameterEnd secDefOptParameterEndProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void softDollarTiersProtoBuf(SoftDollarTiers softDollarTiersProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void familyCodesProtoBuf(FamilyCodes familyCodesProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void symbolSamplesProtoBuf(SymbolSamples symbolSamplesProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void smartComponentsProtoBuf(SmartComponents smartComponentsProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void marketRuleProtoBuf(MarketRule marketRuleProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void userInfoProtoBuf(UserInfo userInfoProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void nextValidIdProtoBuf(NextValidId nextValidIdProto)
        {
            Console.WriteLine("IB Connected via ProtoBuf");
            _connectionTcs.TrySetResult(true);
        }

        public void currentTimeProtoBuf(CurrentTime currentTimeProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void currentTimeInMillisProtoBuf(CurrentTimeInMillis currentTimeInMillisProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void verifyMessageApiProtoBuf(VerifyMessageApi verifyMessageApiProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void verifyCompletedProtoBuf(VerifyCompleted verifyCompletedProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void displayGroupListProtoBuf(DisplayGroupList displayGroupListProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void displayGroupUpdatedProtoBuf(DisplayGroupUpdated displayGroupUpdatedProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void marketDepthExchangesProtoBuf(MarketDepthExchanges marketDepthExchangesProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void configResponseProtoBuf(ConfigResponse configResponseProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        public void updateConfigResponseProtoBuf(UpdateConfigResponse updateConfigResponseProto)
        {
           Debugger.Break();   throw new NotImplementedException();
        }

        // שאר ה-EWrapper methods...
    }
}
