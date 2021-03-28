using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xpeppers.Chirper.Abstraction;

namespace Xpeppers.Chirper
{
    public class ConsoleInputReader : IInputReader
    {
        private IUserService _userService;
        private IOutputPrinter _outputPrinter;
        private string _input;
        string[] _inputBreakdown;
        private string _userName;
        private string _command;
        private string _details;

        public ConsoleInputReader(IUserService userService, IOutputPrinter outputPrinter)
        {
            _userService = userService;
            _outputPrinter = outputPrinter;
        }

        public void ReadInput()
        {
            while (true)
            {
                ResetInput();

                _input = Console.ReadLine();
                _inputBreakdown = Regex.Split(_input, "(->)|(registers)|(unfollows)|(follows)|(wall)").Select(s => s.Trim()).ToArray();

                if (_inputBreakdown.Any() == false)
                {
                    continue;
                }

                _userName = _inputBreakdown[0];
                _command = _inputBreakdown.Length == 1 ? null : _inputBreakdown[1];
                _details = _inputBreakdown.Length == 1 ? null : _inputBreakdown[2];
            
                if (_command == null)
                {
                    _outputPrinter.PrintTweets(_userService.GetTweets(_userName), false);
                }
                else
                {
                    switch (_command)
                    {
                        case "registers": _userService.Register(_userName); break;
                        case "->": _userService.Tweet(_userName, _details); break;
                        case "follows": _userService.Follow(_userName, _details); break;
                        case "unfollows": _userService.Unfollow(_userName, _details); break;
                        case "wall": _outputPrinter.PrintTweets(_userService.GetWall(_userName), true); break;
                        default: continue;
                    }
                }
            }
        }

        private void ResetInput()
        {
            _input = null;
            _inputBreakdown = null;
            _userName = null;
            _command = null;
            _details = null;
        }
    }
}
