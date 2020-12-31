<template>
  <div class="list-component container-fluid">
    <div class="row justify-content-between align-items-center border-rounded bg-light shadow radius15 my-3 p-4">
      <div class="col-8 d-flex align-items-center">
        <router-link :to="{name: 'ActiveList', params: {id: list.id}}" @click="setActiveList(list.id)">
          <h5 class="text-dark">
            {{ list.title }}
          </h5>
        </router-link>
      </div>
      <div class="col-3 d-flex align-items-center">
        <button @click="deleteList(list.id)" class="btn bg-transparent text-dark">
          <i class="fas fa-times"></i>
        </button>
        <button class="btn bg-transparent text-dark ml-1" data-toggle="modal" :data-target="'#editListModal' + list.id">
          <i class="far fa-edit"></i>
        </button>
        <button class="btn bg-transparent text-dark ml-1">
          <i class="fas fa-list-ol"></i>
        </button>
      </div>
    </div>
  </div>
  <div class="modal" :id="'editListModal' + list.id" tabindex="-1">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">
            Edit list title
          </h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <form @submit="editList(state.editedList, list.id)">
          <div class="form-group">
            <input type="text"
                   class="form-control"
                   id="listTitle"
                   aria-describedby="listTitle"
                   placeholder="New list name..."
                   v-model="state.editedList.title"
            >
          </div>
          <button type="submit" class="btn btn-primary mb-3">
            Edit List
          </button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { listsService } from '../services/ListsService'
export default {
  name: 'ListComponent',
  props: ['listProp'],
  setup(props) {
    const state = reactive({
      editedList: {

      }
    })
    return {
      state,
      list: computed(() => props.listProp),
      profile: computed(() => AppState.profile),
      deleteList(id) {
        listsService.deleteList(id)
      },
      editList(editData, id) {
        listsService.editList(editData, id)
      },
      setActiveList(listId) {
        listsService.setActiveList(listId)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.radius15 {
  border-radius: 15px;
}
</style>
