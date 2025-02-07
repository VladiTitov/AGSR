# AGSR
Test task for AGSR company

#### Npm

Run in project directory
```shell
cd src
```
And then run docker compose

```shell
docker compose -p MaternityHospital-app -f docker-compose.yml -f docker-compose.override.yml --env-file .env up -d
```

#### Ports

| Service                     | Port           |
| --------------------------- | -------------- |
| db.mongo                    | 5001           |
| maternity.hospital.api      | 5000           |

