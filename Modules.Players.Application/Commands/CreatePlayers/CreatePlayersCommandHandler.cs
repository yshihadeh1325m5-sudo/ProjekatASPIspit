using Modules.Players.Domain;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Modules.Players.Application.Commands.CreatePlayer
{
    public class CreatePlayersCommandHandler
    {
        private readonly IPlayerRepository _playerRepository;

        public CreatePlayersCommandHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task HandleAsync(CreatePlayersCommand command)
        {
            var player = new Player(command.Name, command.Age, command.Position, command.JerseyNumber, command.TeamId);

            await _playerRepository.AddAsync(player);
        }
    }
}