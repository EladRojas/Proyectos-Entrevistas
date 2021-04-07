select distinct(ps.name) as nombre_institucion
from public_service as ps
inner join permit p on p.public_service_id = ps.id
inner join permit_request pr on pr.permit_id = p.id
where pr.project_id not in
(
	select p.id 
	from project as p
	inner join company as c on c.id = p.company_id
	where c.name = 'MORGAN SA'
)