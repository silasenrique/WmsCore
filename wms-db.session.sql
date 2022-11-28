select c.id customer_id
from customer c,
    (
        select b.customer_id customer_id,
            count(b.owner_id) owner_id
        from customer_owner b
        where b.customer_id in (
                select a.customer_id
                from customer_owner a
                where a.owner_id = '2a6f7a0e-aebf-4085-be51-c6da5dea8c2b'
            )
        group by b.customer_id
        having count(b.owner_id) = 1
    ) d
where c.id = d.customer_id;