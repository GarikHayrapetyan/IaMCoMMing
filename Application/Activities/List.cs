﻿using Domain;
using MediatR;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            private readonly ILogger _logger;

            public Handler(DataContext context,ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
               /* try
                {
                    for (int i = 10 - 1; i >= 0; i--)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000,cancellationToken);
                        _logger.LogInformation($"Task {i} is completed.");
                    }
                }
                catch (Exception ex) when(ex is TaskCanceledException)
                {

                    _logger.LogInformation($"Task was cancelled.");
                }*/

                var activities = await _context.Activities.ToListAsync(cancellationToken);

                return activities;
            }
        }
    }
}
