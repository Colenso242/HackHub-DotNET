using HackHub_DotNET.Domain;
using HackHub_DotNET.Domain.Repositories;

namespace HackHub_DotNET.Infrastructure.Persistence.Repositories;

public sealed class AppointmentRepository(HackHubDbContext context) : Repository<Appointment>(context), IAppointmentRepository;
