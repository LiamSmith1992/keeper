<template>
  <div class="container-fluid">

    <div class="about text-center">
      <section class="row cover-img m-2 rounded">
        <div class="col-11 d-flex text-center">
        </div>
      </section>


      <img class="rounded-pill" :src="account.picture" alt="" />
      <h1>{{ account.name }}</h1>
      <p>{{ account.email }}</p>
    </div>

    <div class="text-center">
      <div>Vaults:{{ vaults.length }}</div>
      <div>Keeps:{{ keeps.length }}</div>
    </div>

    <section v-if="vaults" class="row">
      <div class=" d-flex justify-content-center">
        <div class="underline col-3 d-flex justify-content-center">
          <h1>Vaults</h1>
          <button class=" ms-2 mdi mdi-plus btn btn-success" title="Create new vault"></button>
        </div>
      </div>
      <div v-for="v in vaults" class="col-3 m-2">
        <VaultCard :vaults="v" />

      </div>

    </section>

    <section v-if="keeps" class="row">
      <div class=" d-flex justify-content-center">
        <div class="underline col-3 d-flex justify-content-center">

          <h1>Keeps </h1>
          <button title="Create new keep" class=" ms-2 mdi mdi-plus btn btn-success"></button>
        </div>
      </div>
      <div v-for="k in keeps" class="col-3 m-2">
        <KeepsCard :keeps="k" />
      </div>
    </section>

  </div>




</template>

<script>
import { computed, } from 'vue'
import { AppState } from '../AppState'
import VaultCard from "../components/VaultCard.vue"
import KeepsCard from "../components/KeepsCard.vue"

export default {


  setup() {







    return {
      account: computed(() => AppState.account),
      coverImg: computed(() => `url(${AppState.account?.coverImg})`),
      vaults: computed(() => AppState.accountVaults),
      keeps: computed(() => AppState.accountKeeps),

    }
  },
  components: { VaultCard, KeepsCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
}

.cover-img {
  height: 40vh;
  background-image: v-bind(coverImg);
  object-fit: cover;
  width: 1;
  border: solid 3px black;
}

.underline {
  border-bottom: solid black 6px;
}

.keep-img {
  height: 25vh;
  widows: 100%;
  object-fit: cover;
  object-position: center;
}
</style>
