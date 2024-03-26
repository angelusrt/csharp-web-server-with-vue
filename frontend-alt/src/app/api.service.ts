import axios, { Method } from 'axios';

const client = axios.create({ baseURL: 'http://localhost:5152/api/vote' });

export type Data = { pokemon: number, pseudonym: string };

export default {
    async execute(method: Method, resource: string, data?: Data) {
        return client({ method, url: resource, data, }).then(req => req.data )
    },
    get(): Promise<[number, number, number]|null> { return this.execute('get', '/') },
    post(data: Data) { return this.execute('post', '/', data) },
}
