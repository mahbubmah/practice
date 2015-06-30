using System.Security.Cryptography.X509Certificates;
using OB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OB.BLL.Basic
{
    public class CompetitionInfoRT : IDisposable
    {
        private readonly OiiOBookDCDataContext _dbContext;
        private CompetitionRegistration _CompetitionRegistration;


        public CompetitionInfoRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
            this._CompetitionRegistration = new CompetitionRegistration();

        }
        public CompetitionRegistration GetCompetitionRegistrationrmationID(Int64 IID)
        {
            try
            {
                _CompetitionRegistration = (from ur in _dbContext.CompetitionRegistrations
                                            where ur.IID == IID && ur.IsRemoved == false
                                            select ur).SingleOrDefault();
            
                return _CompetitionRegistration;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        
        public int SelectCompetitionCount()
        {
            try
            {
                var noOfCompetitor = (from com in _dbContext.Competition
                                      where (com.IsRemoved == false)
                                      select com).ToList();

                //  _dbContext.Dispose();
                return noOfCompetitor.Count;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object SelectAllList(int noOfStartRowIndex, int noOfMaximumRows)
        {
            var competitionList = _dbContext.SP_GetAllCompetition(noOfStartRowIndex, noOfMaximumRows).ToList();
            return competitionList;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        

        public void AddCompetitionRegistration(CompetitionRegistration CompetitionRegistration)
        {
            try
            {
                DatabaseHelper.Insert<CompetitionRegistration>(CompetitionRegistration);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
       
        public CompetitionRegistration GetCompetitionRegistrationIDByEmail(string email)
        {
            try
            {
                _CompetitionRegistration = (from tr in _dbContext.CompetitionRegistrations
                                            //where tr.LoginName.Trim().ToLower() == email.Trim().ToLower()
                                            //&& tr.IsActiveUser == true && tr.IsRemoved == false
                                            select tr).SingleOrDefault();
                // _dbContext.Dispose();
                return _CompetitionRegistration;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Contestant FindContestant(string loginName, string userPassword)
        {
            try
            {
                var contestant = (from tr in _dbContext.Contestants
                                  where tr.LoginName.Trim().ToLower() == loginName.Trim().ToLower() && tr.LoginPassword.Trim().ToLower() == userPassword.Trim().ToLower()
                                  && tr.IsActiveUser == true && tr.IsRemoved == false
                                  select tr).SingleOrDefault();
                return contestant;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public Contestant FindContestant(string loginName)
        {
            try
            {
                var contestant = (from tr in _dbContext.Contestants
                                  where tr.LoginName.Trim().ToLower() == loginName.Trim().ToLower() 
                                  && tr.IsActiveUser == true && tr.IsRemoved == false
                                  select tr).SingleOrDefault();
                return contestant;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public List<Competition> GetAllUpComingCompetitionListByContestantId(long contestantId)
        {
            try
            {

                var competitionList = (from competition in _dbContext.Competition.Where(x => x.IsRemoved == false && x.CompetitionEndDate >= GlobalRT.GetServerDateTime())
                                       join compReg in _dbContext.CompetitionRegistrations.Where(x => x.IsRemoved == false) on competition.IID equals compReg.CompetitionID
                                       join contestant in _dbContext.Contestants.Where(x => x.IsRemoved == false && x.IsActiveUser && x.IID == contestantId) on compReg.ContestantId equals contestant.IID
                                       select competition).OrderBy(x => x.CompetitionEndDate).ToList();
              
                return competitionList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public Contestant GetContestantByIid(long contestantId)
        {
            try
            {
                var contestant =
                    _dbContext.Contestants.SingleOrDefault(x => x.IID == contestantId && x.IsActiveUser && x.IsRemoved == false);
                return contestant;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public CompetitionRegistration GetCompetitonRegistrationByCompIdAndContestantId(long compIid, long contestantId)
        {
            try
            {
                var compReg =
                    _dbContext.CompetitionRegistrations.SingleOrDefault(x => x.IsRemoved == false && x.CompetitionID == compIid && x.ContestantId == contestantId);
                return compReg;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateCompetetionRegistration(CompetitionRegistration competitionRegistrationNew)
        {
            try
            {
                CompetitionRegistration compReg = _dbContext.CompetitionRegistrations.SingleOrDefault(d => d.IID == competitionRegistrationNew.IID);

                DatabaseHelper.Update<CompetitionRegistration>(_dbContext, competitionRegistrationNew, compReg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void AddContestant(Contestant contestant)
        {
            try
            {
                DatabaseHelper.Insert<Contestant>(contestant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

